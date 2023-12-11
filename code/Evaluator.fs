module Evaluator

open AST
open SixLabors.ImageSharp
open SixLabors.ImageSharp.Processing
open SixLabors.ImageSharp.PixelFormats

let load(path: string) : Image =
    Image.Load path

let save(path: string)(image: Image) : unit =
    image.Save path |> ignore

let compositeImages(img1: Image)(img2: Image): Image =
    let result = img1.Clone(fun x -> x |> ignore)
    result.Mutate(fun x -> x.DrawImage(img2, new GraphicsOptions
    (AlphaCompositionMode = PixelAlphaCompositionMode.SrcIn)) |> ignore)
    result


let evalEmotion(a: Emotion): string =
    "drawings/" + (a |> string) + ".PNG"

let evalAnimal(a: Animal): string =
    "drawings/" + (a.color |> string) + "_" + (a.animal |> string) + ".PNG"

let evalShoes(a: Shoes): string =
    "drawings/" + (a.color |> string) + "_" + (a.shoes |> string) + ".PNG"

let evalAccessory(a: Accessory): string =
    "drawings/" + (a.color |> string) + "_" + (a.accessory |> string) + ".PNG"

let evalTop(t: Top): string =
    "drawings/" + (t.color |> string) + "_" + (t.top |> string) + ".PNG"

let evalBottom(b: Bottom): string =
    match b.bottom with
    | Blank -> "Blank.PNG"
    | _ -> "drawings/" + (b.color |> string) + "_" + (b.bottom |> string) + ".PNG"