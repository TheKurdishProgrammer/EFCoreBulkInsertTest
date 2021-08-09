# EFCoreBulkInsertTest
This Repository is to test the failing behavior of EFCore.BulkExtention to insert records that have primary key ID Guid with default value (sequentialId()) which sends the Guid's Empty default value instead of letting the DB to create the Guid
