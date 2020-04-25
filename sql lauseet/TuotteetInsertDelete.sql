IF OBJECT_ID('TuotteetDELETE_TR','TR') IS NOT NULL
BEGIN
  DROP TRIGGER TuotteetDELETE_TR
END
GO

-- tehdään laukaisi
CREATE TRIGGER TuotteetDELETE_TR
ON dbo.Tuotteet            -- <-- taulu, johon kytketään
INSTEAD OF DELETE   -- <-- operaatio(t), jonka jälkeen laukaisin suorittuu 
AS
-- laukaisimen algoritmi
BEGIN
DECLARE @EAN NVARCHAR(450)


    SELECT @EAN = EAN
    FROM deleted

      DELETE FROM dbo.TuoteArvostelu
	    WHERE EAN = @EAN

        DELETE FROM dbo.Allergeenit
	    WHERE EAN = @EAN

        DELETE FROM dbo.Ravintoarvot
	    WHERE EAN = @EAN

        DELETE FROM dbo.KaikkiArvostelut
        WHERE EAN = @EAN

        DELETE FROM dbo.Tuotteet
        WHERE EAN = @EAN

        


      print('Tuote ' + @EAN + ' on poistettu.')
  
END
GO