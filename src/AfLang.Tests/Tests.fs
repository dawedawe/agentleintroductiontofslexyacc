module Tests

open FSharp.Text.Lexing
open Lang.Interpreter
open System
open Xunit

let parse source =
    let lexbuf = LexBuffer<char>.FromString source
    let res = Parser.start Lexer.read lexbuf

    match res with
    | Some ast -> ast
    | None -> failwith "failed to parse"

[<Theory>]
[<InlineData("10 + 2", 12)>]
[<InlineData("10 - 2", 8)>]
[<InlineData("10 * 2", 20)>]
[<InlineData("10 / 2", 5)>]
let ``basic math tests`` (source, expected) =
    let ast = parse source
    let r = run ast
    Assert.Equal(expected, r)

[<Theory>]
[<InlineData("2 * 10 + 3", 23)>]
[<InlineData("2 * 10 - 3", 17)>]
[<InlineData("50 / 10 + 3", 8)>]
[<InlineData("50 / 10 - 3", 2)>]
let ``basic precedence tests`` (source, expected) =
    let ast = parse source
    let r = run ast
    Assert.Equal(expected, r)

[<Theory>]
[<InlineData("2 + 10 * 3", 32)>]
[<InlineData("2 - 10 * 3", -28)>]
[<InlineData("50 + 10 / 3", 53)>]
[<InlineData("50 - 10 / 3", 47)>]
let ``basic precedence right side tests`` (source, expected) =
    let ast = parse source
    let r = run ast
    Assert.Equal(expected, r)


[<Theory>]
[<InlineData("2 * (10 + 3)", 26)>]
[<InlineData("2 * (10 - 3)", 14)>]
[<InlineData("10 / (10 + 3)", 0)>]
[<InlineData("10 / (10 - 3)", 1)>]
let ``parens on the right work`` (source, expected) =
    let ast = parse source
    let r = run ast
    Assert.Equal(expected, r)

[<Theory>]
[<InlineData("(2 + 10) * 3", 36)>]
[<InlineData("(2 + 10) / 4", 3)>]
[<InlineData("(10 - 2) * 3", 24)>]
[<InlineData("(10 - 10) / 3", 0)>]
let ``parens on the left work`` (source, expected) =
    let ast = parse source
    let r = run ast
    Assert.Equal(expected, r)

[<Theory>]
[<InlineData("let x = 3", 3)>]
[<InlineData("let x = 3 + 3 * 10", 33)>]
let ``let bindings work`` (source, expected) =
    let ast = parse source
    let r = run ast
    Assert.Equal(expected, r)

[<Fact>]
let ``multiline works`` () =
    let source = """let a = 3
let b = 10 + a
let c = b * 2
c"""
    let ast = parse source
    let r = run ast
    Assert.Equal(26, r)

[<Fact>]
let ``multiline works with empty lines`` () =
    let source = """
       
    
let a = 3

let b = 10 + a
let c = b * 2



c

   


"""
    let ast = parse source
    let r = run ast
    Assert.Equal(26, r)
