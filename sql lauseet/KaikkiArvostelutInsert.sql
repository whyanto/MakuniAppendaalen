IF OBJECT_ID('KaikkiArvostelutINSERT_TR','TR') IS NOT NULL
BEGIN
  DROP TRIGGER KaikkiArvostelutINSERT_TR
END
GO

-- tehdään laukaisi
CREATE TRIGGER KaikkiArvostelutINSERT_TR
ON dbo.KaikkiArvostelut           -- <-- taulu, johon kytketään
INSTEAD OF INSERT   -- <-- operaatio(t), jonka jälkeen laukaisin suorittuu 
AS
-- laukaisimen algoritmi
BEGIN
DECLARE @EAN NVARCHAR(450),
        @TykkasitkoMausta DECIMAL(10,2),
        @TuotteenMakeus DECIMAL(10,2),
        @ToimitJatkossa DECIMAL(10,2),
        @PakkauksenAvaaminen DECIMAL(10,2),
        @RakenneKuiva DECIMAL(10,2),
        @RakenneJauhoinen DECIMAL(10,2),
        @RakenneRapea DECIMAL(10,2),
        @RakenneRoiskuva DECIMAL(10,2),
        @RakenneIlmava DECIMAL(10,2),
        @RakenneKova DECIMAL(10,2),
        @RakennePehmea DECIMAL(10,2),
        @RakenneHajoava DECIMAL(10,2),
        @RakenneTasainen DECIMAL(10,2),
        @MitenKierratetaan DECIMAL(10,2),
        @Kommentti VARCHAR(70),
        @MontaArvostelua DECIMAL(10,2)

     SELECT @EAN = EAN, 
            @TykkasitkoMausta = TykkasitkoMausta,
            @TuotteenMakeus = TuotteenMakeus,
            @ToimitJatkossa = ToimitJatkossa,
            @PakkauksenAvaaminen = PakkauksenAvaaminen,
            @RakenneKuiva = RakenneKuiva,
            @RakenneJauhoinen = RakenneJauhoinen,
            @RakenneRapea = RakenneRapea,
            @RakenneRoiskuva = RakenneRoiskuva,
            @RakenneIlmava = RakenneIlmava,
            @RakenneKova = RakenneKova,
            @RakennePehmea = RakennePehmea,
            @RakenneHajoava = RakenneHajoava,
            @RakenneTasainen = RakenneTasainen,
            @MitenKierratetaan = MitenKierratetaan,
            @Kommentti = Kommentti
      FROM inserted


      INSERT INTO dbo.KaikkiArvostelut(EAN,TykkasitkoMausta,TuotteenMakeus,ToimitJatkossa,PakkauksenAvaaminen,RakenneKuiva,RakenneJauhoinen,RakenneRapea,RakenneRoiskuva,RakenneIlmava,RakenneKova,RakennePehmea,RakenneHajoava,RakenneTasainen,MitenKierratetaan, Kommentti)
      VALUES(@EAN,@TykkasitkoMausta,@TuotteenMakeus,@ToimitJatkossa,@PakkauksenAvaaminen,@RakenneKuiva,@RakenneJauhoinen,@RakenneRapea,@RakenneRoiskuva,@RakenneIlmava,@RakenneKova,@RakennePehmea,@RakenneHajoava,@RakenneTasainen,@MitenKierratetaan, @Kommentti)
      
      SELECT @MontaArvostelua = count(EAN)
      FROM dbo.KaikkiArvostelut
      WHERE EAN = @EAN

      SELECT @TykkasitkoMausta = SUM(TykkasitkoMausta) / @MontaArvostelua,
      @TuotteenMakeus = SUM(TuotteenMakeus) / @MontaArvostelua,
      @ToimitJatkossa = SUM(ToimitJatkossa) / @MontaArvostelua,
      @PakkauksenAvaaminen = SUM(PakkauksenAvaaminen) / @MontaArvostelua,
      @RakenneKuiva = SUM(RakenneKuiva) / @MontaArvostelua,
      @RakenneJauhoinen = SUM(RakenneJauhoinen) / @MontaArvostelua,
      @RakenneRapea = SUM(RakenneRapea) / @MontaArvostelua,
      @RakenneRoiskuva = SUM(RakenneRoiskuva) / @MontaArvostelua,
      @RakenneIlmava = SUM(RakenneIlmava) / @MontaArvostelua,
      @RakenneKova = SUM(RakenneKova) / @MontaArvostelua,
      @RakennePehmea = SUM(RakennePehmea) / @MontaArvostelua,
      @RakenneHajoava = SUM(RakenneHajoava) / @MontaArvostelua,
      @RakenneTasainen = SUM(RakenneTasainen) / @MontaArvostelua,
      @MitenKierratetaan = SUM(MitenKierratetaan) / @MontaArvostelua
      FROM dbo.KaikkiArvostelut
      WHERE EAN = @EAN

            UPDATE dbo.TuoteArvostelu

                  SET TykkasitkoMausta = @TykkasitkoMausta,
                    TuotteenMakeus = @TuotteenMakeus,
                    ToimitJatkossa = @ToimitJatkossa,
                    PakkauksenAvaaminen = @PakkauksenAvaaminen,
                    RakenneKuiva = @RakenneKuiva,
                    RakenneJauhoinen = @RakenneJauhoinen,
                    RakenneRapea = @RakenneRapea,
                    RakenneRoiskuva = @RakenneRoiskuva,
                    RakenneIlmava = @RakenneIlmava,
                    RakenneKova = @RakenneKova,
                    RakennePehmea = @RakennePehmea,
                    RakenneHajoava = @RakenneHajoava,
                    RakenneTasainen = @RakenneTasainen,
                    MitenKierratetaan = @MitenKierratetaan,
                    MontaArvostelua = MontaArvostelua + 1

                  WHERE EAN = @EAN

END
GO