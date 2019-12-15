# Database Connector
Webservice designed to replace the database connections in MS Flow

This is a very stripped down version of the software that we have currently in production

## Input formats

### POST api/Data/Sql
```json
{
  "DatabaseServer": "sqlserver.example.com",
  "DatabaseName": "database1",
  "Username": "testUser",
  "Password": "mySuperSecurePassword",
  "SQL_Query": "SELECT * FROM dbo.tblUsers;"
}
```

## Output formats

* to be added
