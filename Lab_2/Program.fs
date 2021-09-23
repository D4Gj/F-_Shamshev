open System
open System.Text
open System.Drawing



// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
let files = [
    "C:\Users\inzad\Source\Repos\D4Gj\F-_Shamshev\Lab_2\War.txt"
    "C:\Users\inzad\Source\Repos\D4Gj\F-_Shamshev\Lab_2\War1.txt"
    "C:\Users\inzad\Source\Repos\D4Gj\F-_Shamshev\Lab_2\War2.txt"
]
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

//lab2 @"C:\Users\inzad\Source\Repos\D4Gj\F-_Shamshev\Lab_2\War.txt"


let lab3 (arr: int array) =
    printfn "Массив до: \t%A" arr 
    for i in 1 .. arr.Length - 2  do
          if arr.[i-1] % 2 <> 0 && arr.[i+1] % 2 <> 0 && arr.[i] % 2 = 0 then
                Array.set arr i (arr.[i]/2)
    printfn "Массив после: \t%A" arr 

printfn "\n\tЛабораторная работа №3"            
lab3([|1;2;3;4;5;6;7|])


let lab5 path =
    async{
        let book = System.IO.File.ReadAllText(path,Encoding.UTF8)        
        let proj x =
            if Array.contains x [| 'a';'e';'i';'o';'u' |] then 1
                else 0
        let count (text: string) =
                text.ToCharArray()
                |> Array.sumBy proj
            
        printfn $"Найдено:{count book} Всего:{book.Length}"
    }

let lab5Run 0 = 
    printfn "\n\tЛабораторная работа №5"   
    files
    |>List.map lab5
    |>Async.Parallel
    |>Async.RunSynchronously
    |> ignore


[<AbstractClass>]
type Person(name) = 
    member val Name = name with get,set

type Chief(name) = 
    inherit Person(name)

type Worker(name) = 
    inherit Person(name)

let chief = Chief("Andrew")
let worker = Worker("Alexey")

let lab4 0 =
    printfn "\n\tЛабораторная работа №4"   

    printf $"Chief {chief.Name} paying salary to {worker.Name} " 
  

type Rule = char * char list
type Grammar = Rule list

let FindSubst c (gr:Grammar) = 
   match List.tryFind (fun (x,S) -> x=c) gr with
     | Some(x,S) -> S
     | None -> [c]

let Apply (gr:Grammar) L =
   List.collect (fun c -> FindSubst c gr) L

let rec NApply n gr L = 
   if n>0 then Apply gr (NApply (n-1) gr L)
   else L

let str (s:string) =
    [for c in s -> c]

let toString (xs:char list) =
    let sb = System.Text.StringBuilder(xs.Length)
    xs |> List.iter (sb.Append >> ignore)
    sb.ToString()

let TurtleBitmapVisualizer n delta cmd =
    let W,H = 1600,1600
    let b = new Bitmap(W,H)
    let g = Graphics.FromImage(b)
    let pen = new Pen(Color.Black)
    let NewCoord (x:float) (y:float) phi =
       let nx = x+n*cos(phi)
       let ny = y+n*sin(phi)
       (nx,ny,phi)
    let ProcessCommand x y phi = function
     | 'f' -> NewCoord x y phi
     | '+' -> (x,y,phi+delta)
     | '-' -> (x,y,phi-delta)
     | 'F' -> 
         let (nx,ny,phi) = NewCoord x y phi
         g.DrawLine(pen,(float32)x,(float32)y,(float32)nx,(float32)ny)
         (nx,ny,phi)
     | _ -> (x,y,phi)     
    let rec draw x y phi = function
     | [] -> ()
     | h::t ->
         let (nx,ny,nphi) = ProcessCommand x y phi h
         draw nx ny nphi t
    draw (float(W)/2.0) (float(H)/2.0) 0. cmd
    b

let lab6 e =
    let gr = [('F',str "F+F--F+")]
    let lsys = NApply 2 gr (str "+F+F+F+F+")
    lsys |> toString
    let B = TurtleBitmapVisualizer 40.0 (Math.PI/180.0*60.0) lsys
    let path = @"C:\lab\bitmap.jpg"
    B.Save(path)
    printfn $"Bitmap created in {path}"

[<EntryPoint>]
let main argv =    
    lab4 0       
    //lab5Run 0   
    lab6 0
    0 // return an integer exit code
    




