Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class CryptoEngine
    Private Shared ReadOnly salt1() As Byte = {&HB, &H1, &H2, &H3, &H4, &H5, &H6, &HF1, &HF0, &HEE, &H21, &H22, &H45}
    Private Const Iterations As Integer = 1000

    Public Shared Function DataEncrypt(pKeyPhrase As String, pWord As String) As String
        Dim edata1 As Byte()
        Dim EncK As Byte()

        Using bmsk1 As New Rfc2898DeriveBytes(pWord, salt1, Iterations)
            Using encAlg As TripleDES = TripleDES.Create()
                encAlg.Key = bmsk1.GetBytes(24) ' 24 bytes = 192-bit TripleDES
                EncK = encAlg.IV

                Using encryptionStream As New MemoryStream()
                    Using encrypt As New CryptoStream(encryptionStream, encAlg.CreateEncryptor(), CryptoStreamMode.Write)
                        Dim utfD1 As Byte() = Encoding.UTF8.GetBytes(pKeyPhrase)
                        encrypt.Write(utfD1, 0, utfD1.Length)
                        encrypt.FlushFinalBlock()
                        edata1 = encryptionStream.ToArray()
                    End Using
                End Using
            End Using
        End Using

        ' return Base64(cipher) , Base64(IV)
        Return Convert.ToBase64String(edata1) & "," & Convert.ToBase64String(EncK)
    End Function

    Public Shared Function DataDecrypt(pKeyPhrase As String, pWord As String) As String
        Try
            Dim parts() As String = pKeyPhrase.Split(","c)
            Dim vEPassW As Byte() = Convert.FromBase64String(parts(0))
            Dim vEdata As Byte() = Convert.FromBase64String(parts(1))

            Using bmsk2 As New Rfc2898DeriveBytes(pWord, salt1, Iterations)
                Using decAlg As TripleDES = TripleDES.Create()
                    decAlg.Key = bmsk2.GetBytes(24) ' 192-bit
                    decAlg.IV = vEdata

                    Using decryptionStreamBacking As New MemoryStream()
                        Using decrypt As New CryptoStream(decryptionStreamBacking, decAlg.CreateDecryptor(), CryptoStreamMode.Write)
                            decrypt.Write(vEPassW, 0, vEPassW.Length)
                            decrypt.FlushFinalBlock()
                        End Using
                        Return Encoding.UTF8.GetString(decryptionStreamBacking.ToArray())
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class
