open Browser
open FSharp.Text.Lexing
open Lang.Interpreter

let parse source =
    let lexbuf = LexBuffer<char>.FromString source

    try
        Parser.start Lexer.read lexbuf
    with _ ->
        None

let input = document.getElementById "input" :?> Browser.Types.HTMLTextAreaElement
let output = document.getElementById "output" :?> Browser.Types.HTMLTextAreaElement
let runButton = document.getElementById "run" :?> Browser.Types.HTMLButtonElement

runButton.onclick <-
    fun _ ->
        let sourceLines = input.value.Split('\r', '\n')
        let exprs = sourceLines |> Array.map parse

        if Array.contains None exprs then
            output.value <- "parse error"
        else
            let exprs = Array.choose id exprs |> List.ofArray
            output.value <- execute exprs |> string
