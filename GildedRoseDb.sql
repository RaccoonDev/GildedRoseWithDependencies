CREATE TABLE dbo.runs
(
	dates DateTime NOT NULL, 
)
GO

create table dbo.store 
(
	name nvarchar(250) not null,
	quality int,
	sellIn int
)
go

insert into dbo.store values 
('Aged Brie', 10, 10),
('Sulfuras, Hand of Ragnaros', 10, 10),
('Backstage passes to a TAFKAL80ETC concert', 10, 10),
('Backstage passes to a TAFKAL80ETC concert', 10, 10),
('Jar #1', 10, 10),
('Endless sword', 10, 10)


select * from dbo.store 
select * from dbo.runs


