module Evaluator

open AST

let evalAnimal(a: Animal): string =
    (a.color |> string) + "_" + (a.animal |> string) + ".png"
