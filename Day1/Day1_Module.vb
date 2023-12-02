Imports System.IO

Module Day1_Module

    Sub Main()

        Dim firstNum As Long
        Dim lastNum As Long
        Dim total As Long

        For Each line As String In File.ReadLines("D:\AOC_2023\AOC_2023\Day1\Day1_Input.txt")
            For Each digit As Char In line
                If IsNumeric(digit) Then
                    firstNum = Val(digit) * 10
                    Exit For
                End If
            Next digit

            For Each digit As Char In line.Reverse()
                If IsNumeric(digit) Then
                    lastNum = Val(digit)
                    Exit For
                End If
            Next digit

            total += firstNum + lastNum
        Next line

        Console.WriteLine("Part 1 solution = " & total)

        Console.Write("Press any key to continue . . . ")
        Console.ReadKey(True)

    End Sub

End Module
