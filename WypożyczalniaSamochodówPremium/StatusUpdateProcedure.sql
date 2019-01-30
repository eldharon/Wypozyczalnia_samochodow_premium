declare @Id int = 0
declare @IdWypozyczenie int = 0
declare @IdSamochod int = 0
declare @CurrentStatus varchar(50) = ''
declare @Status varchar(50) = ''
declare @counter int = 0
declare @total int = isnull((select count(1) from WypSam), 0)
while (@counter <> (@total))
begin  
        set @Id = (select WypSamId from WypSam order by WypSamId offset @counter rows fetch next 1 rows only)

		set @IdWypozyczenie = (select wyp.WypozyczenieId from WypSam WS
							   join Wypozyczenie wyp on wyp.WypozyczenieId= WS.WypozyczenieId
							   WHERE WS.WypSamId=@Id)

		set @IdSamochod = (select sam.SamochodID from WypSam WS
						   join Samochod sam on sam.SamochodId = WS.SamochodId
						   WHERE WS.WypSamId=@Id)

		set @status = (SELECT CASE WHEN  DATEDIFF(DAY,DataWypozyczenia, GETDATE()) >= DATEDIFF(DAY,DataWypozyczenia,DataZwrotu)
		               THEN 'Dostepny'
		               ELSE 'Niedostepny' END AS [stat]
		               FROM Wypozyczenie
					   WHERE WypozyczenieId = @IdWypozyczenie
					   )

		set @CurrentStatus = (select sam.Status from WypSam WS
						   join Samochod sam on sam.SamochodId = WS.SamochodId
						   WHERE WS.WypSamId=@Id) 

		UPDATE Samochod
		SET Status = @Status
		WHERE @CurrentStatus = 'Niedostepny' AND @CurrentStatus != @Status AND SamochodId = @IdSamochod

		IF @Status='Dostepny' 
		DELETE FROM WypSam WHERE WypSamId = @Id
        
		  
        set @counter = @counter + 1
		end