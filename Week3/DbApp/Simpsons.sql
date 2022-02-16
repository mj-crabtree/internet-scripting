CREATE TABLE "Characters" (
    "CharacterId" INTEGER PRIMARY KEY AUTOINCREMENT,
    "Firstname" NVARCHAR(50) NOT NULL,
    "Lastname" NVARCHAR(50) NOT NULL
);

INSERT INTO "Characters" ( "Firstname", "Lastname" ) VALUES ( "Homer", "Simpson" );
INSERT INTO "Characters" ( "Firstname", "Lastname" ) VALUES ( "Ned", "Flanders" );
INSERT INTO "Characters" ( "Firstname", "Lastname" ) VALUES ( "Nelson", "Muntz" );
INSERT INTO "Characters" ( "Firstname", "Lastname" ) VALUES ( "Barney", "Gumble" );
INSERT INTO "Characters" ( "Firstname", "Lastname" ) VALUES ( "Ralph", "Wiggum" );
