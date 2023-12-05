Imports System.IO

Module Day3_Module

    Sub Main()

        '--- Part 1 ---
        Dim rowIndex As Integer
        Dim colIndex As Integer
        Dim rowCount As Integer
        Dim colCount As Integer
        Dim numDigits As Integer
        Dim validNum As Boolean
        Dim sum As Integer

        Dim i As Integer

        Dim inputFile As String = "D:\AOC_2023\AOC_2023\Day3\Day3_Input.txt"

        rowCount = File.ReadAllLines(inputFile).Length
        colCount = File.ReadAllLines(inputFile)(0).Length
        Dim puzzleInput(rowCount + 1, colCount + 1) As Char

        For rowIndex = 0 To rowCount + 1
            For colIndex = 0 To colCount + 1
                puzzleInput(rowIndex, colIndex) = "."
            Next colIndex
        Next rowIndex

        rowIndex = 1
        For Each line As String In File.ReadLines(inputFile)
            colIndex = 1

            For Each character As Char In line
                puzzleInput(rowIndex, colIndex) = character
                colIndex += 1
            Next character

            rowIndex += 1
        Next line

        For rowIndex = 1 To rowCount
            For colIndex = 1 To colCount

                If IsNumeric(puzzleInput(rowIndex, colIndex)) Then
                    numDigits = 1
                    validNum = False

                    For i = (colIndex + 1) To colCount
                        If IsNumeric(puzzleInput(rowIndex, i)) Then
                            numDigits += 1
                        Else
                            Exit For
                        End If
                    Next i

                    For i = 0 To numDigits - 1
                        If CheckAllNeighbors(puzzleInput, rowIndex, colIndex + i) Then
                            validNum = True
                            Exit For
                        End If
                    Next i

                    If validNum Then
                        For i = 0 To numDigits - 1
                            sum += (Val(puzzleInput(rowIndex, colIndex + i)) * (10 ^ (numDigits - i - 1)))
                        Next i
                    End If

                    colIndex += numDigits
                End If

            Next colIndex
        Next rowIndex

        Console.WriteLine("Part 1 solution = " & sum)

        Console.Write("Press any key to continue . . . ")
        Console.ReadKey(True)

    End Sub

    Function CheckAllNeighbors(puzzleInput(,) As Char, rowIndex As Integer, colIndex As Integer) As Boolean

        If puzzleInput(rowIndex - 1, colIndex - 1) <> "." Or puzzleInput(rowIndex - 1, colIndex) <> "." Or puzzleInput(rowIndex - 1, colIndex + 1) <> "." Or (puzzleInput(rowIndex, colIndex - 1) <> "." And Not IsNumeric(puzzleInput(rowIndex, colIndex - 1))) Or (puzzleInput(rowIndex, colIndex + 1) <> "." And Not IsNumeric(puzzleInput(rowIndex, colIndex + 1))) Or puzzleInput(rowIndex + 1, colIndex - 1) <> "." Or puzzleInput(rowIndex + 1, colIndex) <> "." Or puzzleInput(rowIndex + 1, colIndex + 1) <> "." Then
            CheckAllNeighbors = True
        Else
            CheckAllNeighbors = False
        End If

    End Function

End Module
