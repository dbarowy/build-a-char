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
    img1.Clone(fun x -> x.DrawImage(img2, new GraphicsOptions (AlphaCompositionMode = PixelAlphaCompositionMode.SrcIn)) |> ignore)


let evalEmotion(a: Emotion): string =
    (a |> string) + "_.PNG"

let evalAnimal(a: Animal): string =
    (a.color |> string) + "_" + (a.animal |> string) + ".PNG"

let evalShoes(a: Shoes): string =
    (a.color |> string) + "_" + (a.shoes |> string) + ".PNG"

let evalAccessory(a: Accessory): string =
    (a.color |> string) + "_" + (a.accessory |> string) + ".PNG"

let evalTop(t: Top): string =
    (t.color |> string) + "_" + (t.top |> string) + ".PNG"

let evalBottom(b: Bottom): string =
    match b.bottom with
    | Blank -> "Blank.PNG"
    | _ -> (b.color |> string) + "_" + (b.bottom |> string) + ".PNG"