Imports System.IO

Module Day1_Module

    Sub Main()

        ' --- Part 1 ---
        Dim firstNum As Long
        Dim lastNum As Long
        Dim totalPart1 As Long

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

            totalPart1 += firstNum + lastNum
        Next line

        Console.WriteLine("Part 1 solution = " & totalPart1)


        ' --- Part 2 ---
        Dim intArray() As String = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}
        Dim stringArray() As String = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"}
        Dim returnedIndex As Long
        Dim currentIndexString As Long
        Dim currentIndexInt As Long
        Dim stringNum As Long
        Dim intNum As Long
        Dim totalPart2 As Long

        For Each line As String In File.ReadLines("D:\AOC_2023\AOC_2023\Day1\Day1_Input.txt")

            currentIndexString = line.Length
            For i = 0 To UBound(stringArray)
                returnedIndex = line.IndexOf(stringArray(i))
                If returnedIndex <> -1 And returnedIndex < currentIndexString Then
                    currentIndexString = returnedIndex
                    stringNum = i
                End If
            Next i

            currentIndexInt = line.Length
            For i = 0 To UBound(intArray)
                returnedIndex = line.IndexOf(intArray(i))
                If returnedIndex <> -1 And returnedIndex < currentIndexInt Then
                    currentIndexInt = returnedIndex
                    intNum = i
                End If
            Next i

            If currentIndexInt < currentIndexString Then
                firstNum = intNum
            Else
                firstNum = stringNum
            End If

            currentIndexString = -1
            For i = 0 To UBound(stringArray)
                returnedIndex = line.LastIndexOf(stringArray(i))
                If returnedIndex <> -1 And returnedIndex > currentIndexString Then
                    currentIndexString = returnedIndex
                    stringNum = i
                End If
            Next i

            currentIndexInt = -1
            For i = 0 To UBound(intArray)
                returnedIndex = line.LastIndexOf(intArray(i))
                If returnedIndex <> -1 And returnedIndex > currentIndexInt Then
                    currentIndexInt = returnedIndex
                    intNum = i
                End If
            Next i

            If currentIndexInt > currentIndexString Then
                lastNum = intNum
            Else
                lastNum = stringNum
            End If

            totalPart2 += (firstNum * 10) + lastNum
        Next line

        Console.WriteLine("Part 2 solution = " & totalPart2)


        Console.Write("Press any key to continue . . . ")
        Console.ReadKey(True)

    End Sub

End Module
