Imports System.IO

Module Day2_Module

    Sub Main()

        '--- Part 1 ---
        Dim loadedRed As Long = 12
        Dim loadedGreen As Long = 13
        Dim loadedBlue As Long = 14

        Dim splitLine() As String
        Dim splitGames() As String
        Dim splitRolls() As String
        Dim splitCube() As String
        Dim gameNum As Integer
        Dim gameTotal As Integer
        Dim gameValid As Boolean

        For Each line As String In File.ReadLines("D:\AOC_2023\AOC_2023\Day2\Day2_Input.txt")

            gameValid = True
            gameNum += 1

            splitLine = line.Split(":")
            splitGames = splitLine(1).Split(";")

            For Each game In splitGames
                splitRolls = game.Split(",")
                For Each roll In splitRolls
                    splitCube = roll.Substring(1).Split(" ")
                    If splitCube(1) = "red" Then
                        If Val(splitCube(0)) > loadedRed Then
                            gameValid = False
                            Exit For
                        End If
                    ElseIf splitCube(1) = "green" Then
                        If Val(splitCube(0)) > loadedGreen Then
                            gameValid = False
                            Exit For
                        End If
                    ElseIf splitCube(1) = "blue" Then
                        If Val(splitCube(0)) > loadedBlue Then
                            gameValid = False
                            Exit For
                        End If
                    End If
                Next roll
            Next game

            If gameValid = True Then
                gameTotal += gameNum
            End If
        Next line

        Console.WriteLine("Part 1 solution = " & gameTotal)


        '--- Part 2 ---


        Console.Write("Press any key to continue . . . ")
        Console.ReadKey(True)

    End Sub

End Module
