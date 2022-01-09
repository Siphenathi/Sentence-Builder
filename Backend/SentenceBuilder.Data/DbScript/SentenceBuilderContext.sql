create database SentenceBuilderContext;
use SentenceBuilderContext;

CREATE TABLE WordType (
  WordTypeId int not null identity(1,100),
  Name varchar(50) not null,
  Description varchar(max) null,
  RecordDate Date not null,
  Active bit DEFAULT 1

  constraint PK_WordType primary key clustered
  (
    WordTypeId
  )
)
GO

CREATE TABLE Word (
  WordId int not null identity(1,300),
  WordTypeId int not null,
  Name varchar(50)  not null,
  RecordDate Date not null,
  Active bit DEFAULT 1

  constraint FK_Word_WordType foreign key (WordTypeId) references WordType(WordTypeId),
  constraint PK_Word primary key clustered
  (
    WordId
  )
)
GO

CREATE TABLE Sentence(
  SentenceId int not null identity(1,500),
  Text varchar(max) not null,
  RecordDate Date not null
)

--EXEC sp_RENAME 'Sentence.Name' , 'Text', 'COLUMN'


GO
CREATE UNIQUE NONCLUSTERED INDEX IX_WordType_Id ON WordType(WordTypeId)
GO
CREATE UNIQUE NONCLUSTERED INDEX IX_Word_Id ON Word(WordId)
GO
CREATE UNIQUE NONCLUSTERED INDEX IX_Sentence_Id ON Sentence(SentenceId)
GO

INSERT INTO WordType (Name, Description, RecordDate, Active) 
VALUES ('Noun','is a word that refers to a thing (book), a person (Betty Crocker), an animal (cat)', GETDATE(), 1),
('Verb','are words that show an action (sing), occurrence (develop), or state of being (exist)', GETDATE(), 1),
('Adjective','a word naming an attribute of a noun', GETDATE(), 1),
('Adverb','are words that usually modify—that is, they limit or restrict the meaning of—verbs', GETDATE(), 1),
('Pronoun','is a word that is used instead of a noun or noun phrase', GETDATE(), 1),
('Preposition','is a word or group of words used before a noun, pronoun, or noun phrase to show direction, time, place, location, spatial relationships', GETDATE(), 1),
('Conjuction','a word used to connect clauses or sentences or to coordinate words in the same clause', GETDATE(), 1),
('Determiner','is a word, phrase, or affix that occurs together with a noun or noun phrase', GETDATE(), 1),
('Exclamation','a sudden cry or remark expressing surprise, strong emotion, or pain', GETDATE(), 1)
GO

INSERT INTO Word (WordTypeId, Name, RecordDate, Active)
--Noun
VALUES (1, 'Man', GETDATE(), 1),
(1, 'Woman', GETDATE(), 1),
(1, 'Teacher', GETDATE(), 1),
(1, 'John', GETDATE(), 1),
(1, 'Mary', GETDATE(), 1),
(1, 'Home', GETDATE(), 1),
(1, 'Office', GETDATE(), 1),
(1, 'Durban', GETDATE(), 1),
(1, 'South Africa', GETDATE(), 1),
(1, 'BMW', GETDATE(), 1),
--Verb
(101, 'run', GETDATE(), 1),
(101, 'dance', GETDATE(), 1),
(101, 'slide', GETDATE(), 1),
(101, 'jump', GETDATE(), 1),
(101, 'think', GETDATE(), 1),
(101, 'do', GETDATE(), 1),
(101, 'go', GETDATE(), 1),
(101, 'stand', GETDATE(), 1),
(101, 'eat', GETDATE(), 1),
(101, 'play', GETDATE(), 1),
--Adjective
(201, 'beautiful', GETDATE(), 1),
(201, 'enormous', GETDATE(), 1),
(201, 'silly', GETDATE(), 1),
(201, 'yellow', GETDATE(), 1),
(201, 'fast', GETDATE(), 1),
(201, 'many', GETDATE(), 1),
(201, 'few', GETDATE(), 1),
(201, 'millions', GETDATE(), 1),
(201, 'happy', GETDATE(), 1),
(201, 'neat', GETDATE(), 1),
--Adverb
(301, 'soon', GETDATE(), 1),
(301, 'regularly', GETDATE(), 1),
(301, 'briefly', GETDATE(), 1),
(301, 'happily', GETDATE(), 1),
(301, 'locally', GETDATE(), 1),
(301, 'boldly', GETDATE(), 1),
(301, 'unnecessarily', GETDATE(), 1),
(301, 'slowly', GETDATE(), 1),
(301, 'early', GETDATE(), 1),
(301, 'hard', GETDATE(), 1),
--Pronoun
(401, 'He', GETDATE(), 1),
(401, 'She', GETDATE(), 1),
(401, 'you', GETDATE(), 1),
(401, 'me', GETDATE(), 1),
(401, 'I', GETDATE(), 1),
(401, 'We', GETDATE(), 1),
(401, 'us', GETDATE(), 1),
(401, 'This', GETDATE(), 1),
(401, 'That', GETDATE(), 1),
(401, 'They', GETDATE(), 1),
--Preposition
(501, 'at', GETDATE(), 1),
(501, 'for', GETDATE(), 1),
(501, 'in', GETDATE(), 1),
(501, 'off', GETDATE(), 1),
(501, 'on', GETDATE(), 1),
(501, 'over', GETDATE(), 1),
(501, 'under', GETDATE(), 1),
(501, 'to', GETDATE(), 1),
(501, 'by', GETDATE(), 1),
(501, 'above', GETDATE(), 1),
--Conjuction
(601, 'and', GETDATE(), 1),
(601, 'yet', GETDATE(), 1),
(601, 'but', GETDATE(), 1),
(601, 'or', GETDATE(), 1),
(601, 'neither', GETDATE(), 1),
(601, 'whether', GETDATE(), 1),
(601, 'so', GETDATE(), 1),
(601, 'nor', GETDATE(), 1),
(601, 'because', GETDATE(), 1),
(601, 'as', GETDATE(), 1),
--Determiner
(701, 'the', GETDATE(), 1),
(701, 'which', GETDATE(), 1),
(701, 'these', GETDATE(), 1),
(701, 'those', GETDATE(), 1),
(701, 'this', GETDATE(), 1),
(701, 'that', GETDATE(), 1),
(701, 'my', GETDATE(), 1),
(701, 'our', GETDATE(), 1),
(701, 'your', GETDATE(), 1),
(701, 'his', GETDATE(), 1),
--Exclamation
(801, 'the', GETDATE(), 1),
(801, 'which', GETDATE(), 1),
(801, 'these', GETDATE(), 1),
(801, 'those', GETDATE(), 1),
(801, 'this', GETDATE(), 1),
(801, 'that', GETDATE(), 1),
(801, 'my', GETDATE(), 1),
(801, 'our', GETDATE(), 1),
(801, 'your', GETDATE(), 1),
(801, 'his', GETDATE(), 1)