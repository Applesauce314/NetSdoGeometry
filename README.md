NetSdoGeometry
==============
Fork of the [unmanaged NetSdoGeometry Project](https://github.com/mapspiral/NetSdoGeometry)  which it itself a fork of the [project here on CodePlex](http://tf-net.googlecode.com/files/NetSdoGeometry.zip)

IT has been updated to to use Oracle.ManagedDataAccess.Core.
The code snippet below shows how to use it.

```C#
OracleDataReader reader = command.ExecuteReader();

while (reader.Read())
{
    NetSdoGeometry.SdoGeometry geom = reader["geometry"] as NetSdoGeometry.SdoGeometry;
}
```
