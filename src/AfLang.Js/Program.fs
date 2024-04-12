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
runButton.onclick <- fun _ ->
    let source = input.value
    let ast = parse source
    match ast with
    | Some a ->
        output.value <- run a |> string
    | None -> output.value <- "parse error"
