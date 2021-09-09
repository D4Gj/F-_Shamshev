open System
open System.Text


// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
let lab1 anythingToStart = 
       let list:list<int> = [0]
       let rec ContainsNine n =
           if n = 0 
               then false 
               else
           if n%10 = 9
               then true 
               else ContainsNine (n/10)
       let need,noneed = List.partition ContainsNine [1..100]
       //for i in need do
           //printfn "%d" i
       printfn "%d" (List.sum need)

printfn "\tЛабораторная работа №1"
lab1(123)
   
let lab2 path = 
    let book = System.IO.File.ReadAllText(path,Encoding.UTF8)

    let proj x =
        if Array.contains x [| 'a';'e';'i';'o';'u' |] then 1
        else 0

    let count (text: string) =
        text.ToCharArray()
        |> Array.sumBy proj
    
    printfn $"Найдено:{count book} Всего:{book.Length}"

printfn "\n\tЛабораторная работа №2"  

lab2 @"C:\Users\1\Desktop\War.txt"


let lab3 (arr: int array) =
    printfn "Массив до: \t%A" arr 
    for i in 1 .. arr.Length - 2  do
          if arr.[i-1] % 2 <> 0 && arr.[i+1] % 2 <> 0 && arr.[i] % 2 = 0 then
                Array.set arr i (arr.[i]/2)
    printfn "Массив после: \t%A" arr 

printfn "\n\tЛабораторная работа №3"            
lab3([|1;2;3;4;5;6;7|])

// ----- Unused code ----- 

/// lab 2 N**2

//let finding str chars =
//    let mutable counter = 0
//    for wordChar in str do
//        for chr in chars do            
//             if chr.Equals(wordChar) then
//                 printfn $"Found chars: {counter}"
//                 counter <- counter + 1
//    printfn $"Found {counter} chars"