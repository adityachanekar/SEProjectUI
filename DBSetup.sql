CREATE TABLE  "USERD" 
   (	"USERID" NUMBER NOT NULL ENABLE, 
	"USERNAME" VARCHAR2(4000), 
	"PASSWORD" VARCHAR2(4000), 
	 CONSTRAINT "USERD_CON" PRIMARY KEY ("USERID") ENABLE
   )
/
CREATE TABLE  "DETAIL" 
   (	"DETAILID" NUMBER NOT NULL ENABLE, 
	"FNAME" VARCHAR2(4000), 
	"LNAME" VARCHAR2(4000), 
	"DOB" DATE, 
	"CONTACT" VARCHAR2(4000), 
	"USERID" NUMBER, 
	 CONSTRAINT "DETAIL_PK" PRIMARY KEY ("DETAILID") ENABLE, 
	 CONSTRAINT "DETAIL_FK" FOREIGN KEY ("USERID")
	  REFERENCES  "USERD" ("USERID") ENABLE
   )
/
CREATE TABLE  "EXPENSE" 
   (	"EXPENSEID" NUMBER NOT NULL ENABLE, 
	"EXPENSEPARTICULAR" VARCHAR2(4000), 
	"EXPENSEAMOUNT" NUMBER, 
	"EXPENSEDATE" DATE, 
	"USERID" NUMBER, 
	 CONSTRAINT "EXPENSE_PK" PRIMARY KEY ("EXPENSEID") ENABLE, 
	 CONSTRAINT "EXPENSE_FK" FOREIGN KEY ("USERID")
	  REFERENCES  "USERD" ("USERID") ENABLE
   )
/
CREATE TABLE  "INCOME" 
   (	"INCOMEID" NUMBER NOT NULL ENABLE, 
	"INCOMEPARTICULAR" VARCHAR2(4000), 
	"INCOMEAMOUNT" NUMBER, 
	"INCOMEDATE" DATE, 
	"USERID" NUMBER, 
	 CONSTRAINT "INCOME_PK" PRIMARY KEY ("INCOMEID") ENABLE, 
	 CONSTRAINT "INCOME_FK" FOREIGN KEY ("USERID")
	  REFERENCES  "USERD" ("USERID") ENABLE
   )
/
