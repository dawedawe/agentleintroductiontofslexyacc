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
    let context = System.Collections.Generic.Dictionary<string, int>()
    printf "> "
    let mutable input = System.Console.ReadLine()

    while input <> "#q" do
        match parse input with
        | Some ast ->
            try
                let r = eval context ast
                printfn $"%d{r}"
            with e ->
                printfn $"{e.Message}"
        | None -> printfn "failed to parse"

        printf "> "
        input <- System.Console.ReadLine()

[<EntryPoint>]
let main args =
    repl ()
    0
