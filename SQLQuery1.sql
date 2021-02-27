create table [dbo].[data] (
    [ID]                        INT NOT NULL IDENTITY,
    [Question]					NVARCHAR(MAX)     NOT NULL,
    [Answer_1]                  NVARCHAR(MAX)	  NOT NULL,
    [Answer_2]                  NVARCHAR(MAX)     NOT NULL,
    [Answer_3]                  NVARCHAR(MAX)     NOT NULL,
    [Answer_4]                  NVARCHAR(MAX)     NOT NULL,
	[Answer_Right]				NVARCHAR(MAX)     NOT NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC)
);