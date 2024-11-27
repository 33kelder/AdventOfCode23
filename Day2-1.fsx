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

let parseSet (line:string) = 
    let cubes = line.Split ','
    {Blue = 1; Red = 1; Green = 1}

let parseLine (line:string) =
    let id = 
        (line.Split ':').[0].Remove(0, 5) 
        |> int
    let sets = 
        (line.Split ':').[1].Split ';'
        |> Seq.map parseSet
    {ID = id; Sets = sets }

let filterGame (game:Game) =
    Seq.length game.Sets > 0
    
inputLines
|> Seq.map parseLine
|> Seq.filter filterGame
|> Seq.map (fun g -> g.ID)
|> Seq.sum