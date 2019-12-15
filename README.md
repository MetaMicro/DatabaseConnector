# Database Connector
Webservice designed to replace the database connections in MS Flow

This is a very stripped down version of the software that we have currently in production

## POST api/Data/Sql
### Input
```json
{
  "DatabaseServer": "sqlserver.example.com",
  "DatabaseName": "database1",
  "Username": "testUser",
  "Password": "mySuperSecurePassword",
  "SQL_Query": "SELECT * FROM dbo.tblUsers;"
}
```
### Output
```json
{
    "Tables": {
        "Table": [
            {
                "id": 1,
                "Name": "brandon"
            },
            {
                "id": 2,
                "Name": "brandon1"
            },
            {
                "id": 3,
                "Name": "brandon2"
            },
            {
                "id": 4,
                "Name": "brandon3"
            }
        ]
    },
    "Message": "Data successfully retrieved"
}
```

## POST api/Data/MySql
### Input
```json
{
  "DatabaseServer": "mysqlServer.example.com",
  "DatabaseName": "database1",
  "Username": "testUser",
  "Password": "mySuperSecurePassword",
  "SQL_Query": "SELECT * FROM tblUsers;"
}
```
### Output
```json
{
    "Tables": {
        "Table": [
            {
                "id": 1,
                "Name": "brandon"
            },
            {
                "id": 2,
                "Name": "brandon1"
            },
            {
                "id": 3,
                "Name": "brandon2"
            },
            {
                "id": 4,
                "Name": "brandon3"
            }
        ]
    },
    "Message": "Data successfully retrieved"
}
```
