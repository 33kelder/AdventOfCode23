open System
open System.IO

let testInput1 = seq {"1abc2"; "pqr3stu8vwx";"a1b2c3d4e5f"; "treb7uchet"}

let firstDigit stringValue = 
    stringValue
    |> Seq.find (fun ch -> Char.IsDigit ch)
    
let lastDigit stringValue = 
    stringValue
    |> Seq.findBack (fun ch -> Char.IsDigit ch)

let combineFirstAndLastDigit stringValue =
    let fd = firstDigit stringValue
    let ld = lastDigit stringValue
    let combinedString =  String.Concat(string fd, string ld)
    int combinedString

let sumDigits stringSequence =
    stringSequence
    |> Seq.map (fun stringValue -> combineFirstAndLastDigit stringValue)
    |> Seq.sum 

let testResult1 = sumDigits testInput1

let inputPath = Path.Combine(__SOURCE_DIRECTORY__, "Day1PI.txt")
let inputLines = File.ReadAllLines(inputPath)
let firstResult = sumDigits inputLines

