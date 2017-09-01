# RecordTracker
This is a little utility I wrote to help with debugging SQL database data issues.

This is a small utility that I wrote to help me solve problems working with data in a SQL database. When there are records 
that have a lot of links to other records, especially as a result of complex stored procedures, it can be very helpful to track
down the components of the result, seeing each table and row that contributed values. To do this in SSMS means opening up new 
queries and managing the different windows. I wanted something more surgical, that would let me enter table,column and value
and have it pull up the records that matched those in a small window that only contained the result set. Then I could create
a set of these windows, each with a differnet query, that would let me build a picture of where the pieces of a result came from.

It was build with VS 2017 WPF in C# and assumes Sql Server

Hope you find it useful.

John Mott 
