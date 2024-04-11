module Lang

module Ast =

    type Expr =
        | Decl of (string * Expr)
        | Int of int
        | Paren of Expr
        | InfixApp of (Expr * Operator * Expr)
        | Ident of string

    and Operator =
        | MulOp
        | DivOp
        | AddOp
        | SubOp

module Interpreter =

    open System.Collections.Generic
    open Ast

    let rec eval (context: Dictionary<string, int>) (expr: Expr) =
        match expr with
        | Int i -> i
        | Ident i ->
            if context.ContainsKey(i) then
                context[i]
            else
                failwith $"unknown identifier %s{i}"
        | Paren e -> eval context e
        | Decl(ident, e) ->
            let v = eval context e
            context[ident] <- v
            v
        | InfixApp(left, op, right) ->
            let f =
                match op with
                | MulOp -> (*)
                | DivOp -> (/)
                | AddOp -> (+)
                | SubOp -> (-)

            f (eval context left) (eval context right)

    let run (expr: Expr) =
        let context = Dictionary<string, int>()
        eval context expr

    let execute (program: Expr list) =
        let context = Dictionary<string, int>()
        program |> List.map (eval context) |> List.last
