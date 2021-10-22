namespace ClimaTempoSimples.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        EstadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estadoes", t => t.EstadoID, cascadeDelete: true)
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        UF = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PrevisaoClimas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Clima = c.Int(nullable: false),
                        TemperaturaMinima = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TemperaturaMaxima = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataPrevisao = c.DateTime(nullable: false),
                        CidadeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cidades", t => t.CidadeID, cascadeDelete: true)
                .Index(t => t.CidadeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrevisaoClimas", "CidadeID", "dbo.Cidades");
            DropForeignKey("dbo.Cidades", "EstadoID", "dbo.Estadoes");
            DropIndex("dbo.PrevisaoClimas", new[] { "CidadeID" });
            DropIndex("dbo.Cidades", new[] { "EstadoID" });
            DropTable("dbo.PrevisaoClimas");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Cidades");
        }
    }
}
