open Parser
open Evaluator
open System.IO

let rec repl() : unit =
    let input = System.Console.ReadLine()
    if input = "quit" then
        printfn "Goodbye!"
        exit 0
    else
        let asto = parse input
        match asto with
        | Some ast -> 
            let animalOne = load (evalAnimal ast.animal)
            let emotionOne = load (evalEmotion ast.emotion)
            let withEmotion = compositeImages animalOne emotionOne
            let bottomOne = load (evalBottom ast.bottom)
            let withBottom = compositeImages withEmotion bottomOne
            let shoesOne = load (evalShoes ast.shoes)
            let withShoes = compositeImages withBottom shoesOne
            let topOne = load (evalTop ast.top)
            let withTop = compositeImages withShoes topOne
            let accessoryOne = load (evalAccessory ast.accessory)
            (compositeImages withTop accessoryOne) |> save "Character.PNG"
        | None -> printf "Make sure your input is of the form <emotion> <animal> <outfit> <shoes> <accessory>\n"
    repl()

[<EntryPoint>]
let main args =
    printf "-----------------------------------------------------------------------------------------------------------------\n" 
    printf "-----------------------------------------------------------------------------------------------------------------\n" 
    printf " \n Hello! Welcome to Jess Hu and Will Olsen's Build-A-Char! :D \n
    -----------------------------------------------------------------------------------------------\n
    Build-A-Char will accept prompts that look like this: \n
    <emotion> <animal> <top> <bottom> <shoes> <accessory> \n
    and it will return a PNG called Character.PNG of a custom character fitting that description!\n
    -----------------------------------------------------------------------------------------------\n
    Here are the available options for each category:\n
    <emotion>: happy, neutral, sad, mad, or tired\n
    <animal>: <color> bunny, cat, dog, or bear\n
    <top>: <color> tshirt, sweater, hoodie, suit, dress or blank\n
    <bottom>: <color> pants, shorts, skirt, or blank\n
    <shoes>: <color> sneakers, cowboy boots, combat boots, heels, slippers, or blank \n
    <accessory>: <color> flower, star, glasses, sunglasses, scarf, gloves, or blank\n
    <color>: red, orange, yellow, green, blue, purple, pink, white, black, or brown\n
    -----------------------------------------------------------------------------------------------\n
    Here are some example prompts:\n
    happy orange cat blue tshirt green pants black slippers pink flower\n 
    
    sad brown bear pink dress purple cowboy boots blue scarf\n

    neutral white bunny black suit black sneakers yellow star\n \n"
    printf "-----------------------------------------------------------------------------------------------------------------\n"
    printf "-----------------------------------------------------------------------------------------------------------------\n" 
    printf "Please enter a prompt! Type 'quit' when you are done using Build-A-Char!\n"
    repl()
    0