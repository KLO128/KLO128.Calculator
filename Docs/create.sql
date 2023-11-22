DROP TABLE IF EXISTS "CalcEntry";
DROP TABLE IF EXISTS "CalcHistory";
 

CREATE TABLE "CalcHistory" (
	"CalcHistoryId"	INTEGER NOT NULL,
	"Guid"	TEXT NOT NULL,
	"AccessToken"	TEXT NOT NULL,
	"NameToDisplay"	TEXT,
	"CreatedDate" TEXT NOT NULL,
	"UpdatedDate"	TEXT NOT NULL,
	CONSTRAINT "PK_CalcHistory" PRIMARY KEY("CalcHistoryId" AUTOINCREMENT)
);
CREATE TABLE "CalcEntry" (
	"CalcEntryId"	INTEGER NOT NULL,
	"CalcHistoryId"	INTEGER,
	"Expression"	TEXT NOT NULL,
	"Result"	REAL NULL,
	"ErrorCode" TEXT NULL,
	"ErrorArgs" TEXT NULL,
	"CreatedDate"	TEXT NOT NULL,
	CONSTRAINT "PK_CalcEntry" PRIMARY KEY("CalcEntryId" AUTOINCREMENT),
	CONSTRAINT "FK_CalcEntry_CalcHistory" FOREIGN KEY("CalcHistoryId") REFERENCES "CalcHistory"("CalcHistoryId")
);

CREATE INDEX "IXFK_CalcEntry_CalcHistory" ON "CalcEntry" (
	"CalcHistoryId"	ASC
);