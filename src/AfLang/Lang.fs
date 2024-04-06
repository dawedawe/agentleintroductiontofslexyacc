module Lang

module Ast =

    type Expr =
        | Int of int
        | Paren of Expr
        | InfixApp of (Expr * Operator * Expr)

    and Operator =
        | MulOp
        | DivOp
        | AddOp
        | SubOp

module Interpreter =

    open Ast

    let rec run (expr: Expr) =
        match expr with
        | Int i -> i
        | Paren e -> run e
        | InfixApp(left, op, right) ->
            let f =
                match op with
                | MulOp -> (*)
                | DivOp -> (/)
                | AddOp -> (+)
                | SubOp -> (-)

            f (run left) (run right)
