open System
open System.IO

let inputPath = Path.Combine(__SOURCE_DIRECTORY__, "Day2InputTest.txt")

let inputLines = File.ReadAllLines(inputPath)

type Set = {
    Blue: int
    Red: int
    Green: int
}

type Game = {
    ID: int
    Sets: Set seq
}

let loadedSet = {Blue = 14; Red = 12; Green = 13}

let parseLine line =
    {ID = 1; Sets = seq{{Blue = 14; Red = 12; Green = 13}} }

let filterGame (game:Game) =
    Seq.length game.Sets > 0
    
inputLines
|> Seq.map parseLine
|> Seq.filter filterGame
|> Seq.map (fun g -> g.ID)
|> Seq.sum