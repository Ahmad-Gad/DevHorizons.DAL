Simi ORM (Object Relational Mapping) Library – All the inputs and outputs can be strong typed objects. No need for additional data transformation/auto mapper libraries/operation.
Two levels of caching to cache most of the applicable reflection generated objects using the DI Singleton lifecycle. Plus, full control and monitor on the memory cache size.
Full support for all the SQL data types either through parameters or the returned data.
Full integration with the Stored Procedures with the support of the return parameters (OOTB), output parameters, and structured/table parameters.
Full support for the transaction operations (TCL) with the desired isolation level specified (optional).
Supports data hashing and data symmetric encryption/decryption on the client side for the inbound/outbound data automatically (OOTB) without any extra code.
Ultimate errors and exceptions handling and logging OOTB.
Ultimate control over the library through detailed settings to control the cache, the encryption/hash algorithms/hashes, the logging, the error/exception advanced details and more.
The “DevHorizons.DAL.Sql” is the only valid/testes/stable implementation of “DevHorizons.DAL” so far which leverage all the power of the SQL Server and supports all the data types until SQL Server 2019. This is the library/package would need to add to your .NET Standard/Core project either Desktop Application, Class Library, Web Application or WebAPI.
