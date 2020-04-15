CREATE TABLE [dbo].[Contribution] (
    [contributionid]       INT IDENTITY(1,1)         NOT NULL,
    [uwtype]               VARCHAR (10)     NULL,
    [uwmonthly]            DECIMAL(16,2)          NULL,
    [uwmonths]             INT          NULL,
    [uwcontributionamount] DECIMAL(16,2)         NULL,
    [uwdate]               DATE         NULL,
    [uwyear]               INT          NULL,
    [cwid]                 INT          NULL,
    [agencyid]             INT          NULL,
    PRIMARY KEY CLUSTERED ([contributionid] ASC),
    FOREIGN KEY ([agencyid]) REFERENCES [dbo].[Agency] ([agencyid]),
    FOREIGN KEY ([cwid]) REFERENCES [dbo].[Employee] ([cwid])
);

