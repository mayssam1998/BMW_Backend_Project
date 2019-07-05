FROM microsoft/dotnet:2.2-sdk AS builder

WORKDIR /sln

#copy the solution file 
COPY ./Supplier-Service-Backend.sln ./

#copy the nuget configuration containing proxy settings
# COPY ./NuGet.Config /root/.nuget/NuGet/

#copy everything
COPY ./ .

WORKDIR ./Src/Presentation/SuS.WebApi

RUN apt-get update && apt-get install -y libcurl3

#build projects and restore packages
RUN dotnet restore

RUN dotnet build -c Release --no-restore

RUN dotnet publish -c Release -o "/sln/dist" --no-restore

FROM microsoft/dotnet:2.2-aspnetcore-runtime
ARG source
WORKDIR /app
COPY --from=builder /sln/dist .
ENTRYPOINT ["dotnet", "SuS.WebApi.dll"]

