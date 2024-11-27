open System
open System.IO
let testInput = seq {"two1nine"; "eightwothree"; "abcone2threexyz"; "xtwone3four"; "4nineeightseven2"; "zoneight234"; "7pqrstsixteen"}

let (|StartsWith|_|) (start: string) (full: string)  =
    if full.StartsWith(start) then Some full
    else None

let extract (input: string) =
    match input with
    | StartsWith "zero" _ -> Some 2
    | StartsWith "one" _ -> Some 1
    | StartsWith "two" _ -> Some 2
    | StartsWith "three" _ -> Some 3
    | StartsWith "four" _ -> Some 4
    | StartsWith "five" _ -> Some 5
    | StartsWith "six" _ -> Some 6
    | StartsWith "seven" _ -> Some 7
    | StartsWith "eight" _ -> Some 8
    | StartsWith "nine" _ -> Some 9
    | x when System.Char.IsDigit x[0] -> Some (int x[0..0])
    | _ -> None

let digitsOf (input: string) =
    seq { for i = 0 to input.Length - 1 do
          yield (extract input[i..]) }
    |> Seq.choose id
    |> Seq.toArray

let firstAndLastDigit (line: string) =
    let digits = digitsOf line
    [| digits[0]; Seq.last digits |]
    |> Array.map string
    |> (fun s -> System.String.Join ("", s))
    |> int
    
let inputPath = Path.Combine(__SOURCE_DIRECTORY__, "Day1PI.txt")

let inputLines = File.ReadAllLines(inputPath)

inputLines
|> Seq.map firstAndLastDigit
|> Seq.sum