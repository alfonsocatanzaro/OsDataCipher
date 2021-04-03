<a name='assembly'></a>
# OsDataCipher

## Contents

- [IOsDataCipher](#T-OsDataCipher-IOsDataCipher 'OsDataCipher.IOsDataCipher')
  - [Decrypt(data)](#M-OsDataCipher-IOsDataCipher-Decrypt-System-String- 'OsDataCipher.IOsDataCipher.Decrypt(System.String)')
  - [Encrypt(data)](#M-OsDataCipher-IOsDataCipher-Encrypt-System-String- 'OsDataCipher.IOsDataCipher.Encrypt(System.String)')
  - [TryDecrypt(encrypted,decrypted)](#M-OsDataCipher-IOsDataCipher-TryDecrypt-System-String,System-String@- 'OsDataCipher.IOsDataCipher.TryDecrypt(System.String,System.String@)')
- [OsDataCipher](#T-OsDataCipher-OsDataCipher 'OsDataCipher.OsDataCipher')
  - [#ctor(password)](#M-OsDataCipher-OsDataCipher-#ctor-System-String- 'OsDataCipher.OsDataCipher.#ctor(System.String)')
  - [Decrypt(data)](#M-OsDataCipher-OsDataCipher-Decrypt-System-String- 'OsDataCipher.OsDataCipher.Decrypt(System.String)')
  - [Encrypt(data)](#M-OsDataCipher-OsDataCipher-Encrypt-System-String- 'OsDataCipher.OsDataCipher.Encrypt(System.String)')
  - [TryDecrypt(encrypted,decrypted)](#M-OsDataCipher-OsDataCipher-TryDecrypt-System-String,System-String@- 'OsDataCipher.OsDataCipher.TryDecrypt(System.String,System.String@)')

<a name='T-OsDataCipher-IOsDataCipher'></a>
## IOsDataCipher `type`

##### Namespace

OsDataCipher

##### Summary

IOsDataCippher inteface

<a name='M-OsDataCipher-IOsDataCipher-Decrypt-System-String-'></a>
### Decrypt(data) `method`

##### Summary

Decrypt a crypted string

##### Returns

Decrypted string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String to decrypt |

<a name='M-OsDataCipher-IOsDataCipher-Encrypt-System-String-'></a>
### Encrypt(data) `method`

##### Summary

Encrypt a string

##### Returns

Encrypted string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String to encrypt |

<a name='M-OsDataCipher-IOsDataCipher-TryDecrypt-System-String,System-String@-'></a>
### TryDecrypt(encrypted,decrypted) `method`

##### Summary

Try to decrypt a string

##### Returns

True for decrypt successfull

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| encrypted | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Encrypted string to try for decrypt |
| decrypted | [System.String@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String@ 'System.String@') | Decrypted strings |

<a name='T-OsDataCipher-OsDataCipher'></a>
## OsDataCipher `type`

##### Namespace

OsDataCipher

##### Summary

OsDataCipher provide basic and optimized functionality
for encrypt and decrypt string using a custom-length pass-phrase

<a name='M-OsDataCipher-OsDataCipher-#ctor-System-String-'></a>
### #ctor(password) `constructor`

##### Summary

Create a [OsDataCipher](#T-OsDataCipher-OsDataCipher 'OsDataCipher.OsDataCipher') class instance

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A password to use for encrypt and decrypt operations |

<a name='M-OsDataCipher-OsDataCipher-Decrypt-System-String-'></a>
### Decrypt(data) `method`

##### Summary

Decrypt a encrypted string

##### Returns

Decrypted string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Base64 string to decrypt |

<a name='M-OsDataCipher-OsDataCipher-Encrypt-System-String-'></a>
### Encrypt(data) `method`

##### Summary

Encrypt a string

##### Returns

Base64 encrypted string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String to encrypt |

<a name='M-OsDataCipher-OsDataCipher-TryDecrypt-System-String,System-String@-'></a>
### TryDecrypt(encrypted,decrypted) `method`

##### Summary

Try to decrypt a string

##### Returns

True for decrypt successful

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| encrypted | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Base64 encrypted string to try for decrypt |
| decrypted | [System.String@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String@ 'System.String@') | Decrypted strings |
