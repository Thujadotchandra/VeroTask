USE [VeroTest]
GO

declare @i as int =1


while @i<=15
begin

	INSERT INTO [dbo].[Song]
			   ([Id]
			   ,[SongName]
			   ,[Price]
			   ,[Lyrics]
			   ,[Cover]
			   ,[Genres]
			   ,[Language]
			   ,[Artist]
			   ,[Created]
			   )
		 VALUES
			   (@i
			   ,'TestSong'+cast (@i as varchar(10))
			   ,23.56+@i
			   ,'TestLyrics'+cast (@i as varchar(10))
			   ,'TestCover'+cast (@i as varchar(10))
			   ,'TestGenres'+cast (@i as varchar(10))
			   ,'TestLanguage'+cast (@i as varchar(10))
			   ,'TestArtist'+cast (@i as varchar(10))
			   ,GETDATE()
			   )

	set @i=@i+1
end

Go