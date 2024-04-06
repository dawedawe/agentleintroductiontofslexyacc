module Program

open FSharp.Text.Lexing
open Lang.Interpreter

let parse source =
    let lexbuf = LexBuffer<char>.FromString source

    try
        Parser.start Lexer.read lexbuf
    with _ ->
        None

let repl () =
    printf "> "
    let mutable input = System.Console.ReadLine()

    while input <> "q" do
        match parse input with
        | Some ast ->
            let r = run ast
            printfn $"%d{r}"
        | None -> printfn "failed to parse"

        printf "> "
        input <- System.Console.ReadLine()

[<EntryPoint>]
let main args =
    repl ()
    0
