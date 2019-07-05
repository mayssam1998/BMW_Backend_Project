ALTER TABLE "COUNTRY" DROP CONSTRAINT "fk_COUNTRY_REGION";
ALTER TABLE "CITY" DROP CONSTRAINT "fk_CITY_COUNTRY";
ALTER TABLE "STREET" DROP CONSTRAINT "fk_STREET_CITY";
ALTER TABLE "BRANCH" DROP CONSTRAINT "fk_BRANCH_STREET";
ALTER TABLE "SUPPLIER" DROP CONSTRAINT "fk_SUPPLIER_TYPE";
ALTER TABLE "ALTERNATE_NAME" DROP CONSTRAINT "fk_ALTERNATE_NAME_SUPPLIER";
ALTER TABLE "BRANCH" DROP CONSTRAINT "fk_BRANCH_SUPPLIER";

ALTER TABLE "BRANCH" DROP CONSTRAINT "UQ_NR_ZA";
ALTER TABLE "SUPPLIER" DROP CONSTRAINT "NUMBER";

DROP TABLE "REGION";
DROP TABLE "COUNTRY";
DROP TABLE "CITY";
DROP TABLE "STREET";
DROP TABLE "BRANCH";
DROP TABLE "SUPPLIER";
DROP TABLE "ALTERNATE_NAME";
DROP TABLE "TYPE";

CREATE TABLE "REGION" (
"ID" serial8 NOT NULL,
"NAME" varchar(255),
PRIMARY KEY ("ID") 
)
WITHOUT OIDS;
CREATE TABLE "COUNTRY" (
"ID" serial8 NOT NULL,
"NAME" varchar(255),
"ISO2" varchar(255),
"ISO3" varchar(255),
"REGION_ID" int8,
PRIMARY KEY ("ID") 
)
WITHOUT OIDS;
CREATE TABLE "CITY" (
"ID" serial8 NOT NULL,
"NAME" varchar(255),
"COUNTRY_ID" int8,
PRIMARY KEY ("ID") 
)
WITHOUT OIDS;
CREATE TABLE "STREET" (
"ID" serial8 NOT NULL,
"NAME" varchar(255),
"CITY_ID" int8,
PRIMARY KEY ("ID") 
)
WITHOUT OIDS;
CREATE TABLE "BRANCH" (
"ID" serial8 NOT NULL,
"NUMBER" varchar(255),
"NAME" varchar(255),
"POST_CODE" varchar(255),
"STREET_ID" int8,
"SUPPLIER_ID" int8,
PRIMARY KEY ("ID") ,
CONSTRAINT "UQ_NR_ZA" UNIQUE ("NUMBER", "SUPPLIER_ID")
)
WITHOUT OIDS;
CREATE TABLE "SUPPLIER" (
"ID" serial8 NOT NULL,
"NAME" varchar(255),
"NUMBER" varchar(255),
"TYPE_ID" int8,
PRIMARY KEY ("ID") ,
CONSTRAINT "NUMBER" UNIQUE ("NUMBER")
)
WITHOUT OIDS;
CREATE TABLE "ALTERNATE_NAME" (
"ID" serial8 NOT NULL,
"NAME" varchar(255),
"SUPPLIER_ID" int8,
PRIMARY KEY ("ID") 
)
WITHOUT OIDS;
CREATE TABLE "TYPE" (
"ID" serial8 NOT NULL,
"NAME" varchar(255),
PRIMARY KEY ("ID") 
)
WITHOUT OIDS;

ALTER TABLE "COUNTRY" ADD CONSTRAINT "fk_COUNTRY_REGION" FOREIGN KEY ("REGION_ID") REFERENCES "REGION" ("ID");
ALTER TABLE "CITY" ADD CONSTRAINT "fk_CITY_COUNTRY" FOREIGN KEY ("COUNTRY_ID") REFERENCES "COUNTRY" ("ID");
ALTER TABLE "STREET" ADD CONSTRAINT "fk_STREET_CITY" FOREIGN KEY ("CITY_ID") REFERENCES "CITY" ("ID");
ALTER TABLE "BRANCH" ADD CONSTRAINT "fk_BRANCH_STREET" FOREIGN KEY ("STREET_ID") REFERENCES "STREET" ("ID");
ALTER TABLE "SUPPLIER" ADD CONSTRAINT "fk_SUPPLIER_TYPE" FOREIGN KEY ("TYPE_ID") REFERENCES "TYPE" ("ID");
ALTER TABLE "ALTERNATE_NAME" ADD CONSTRAINT "fk_ALTERNATE_NAME_SUPPLIER" FOREIGN KEY ("SUPPLIER_ID") REFERENCES "SUPPLIER" ("ID");
ALTER TABLE "BRANCH" ADD CONSTRAINT "fk_BRANCH_SUPPLIER" FOREIGN KEY ("SUPPLIER_ID") REFERENCES "SUPPLIER" ("ID");
