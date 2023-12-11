module AST

type Color =
| Red
| Orange
| Yellow
| Green
| Blue
| Purple
| Pink
| Black
| White
| Brown

type AnimalNoColor =
| Bunny
| Cat
| Frog
| Bear

type Animal = { color: Color; animal: AnimalNoColor }

type Emotion =
| Happy
| Neutral
| Sad
| Mad
| Tired

type TopNoColor =
| Tshirt
| Sweater
| Hoodie
| Suit
| Dress

type Top = { color: Color; top: TopNoColor }

type BottomNoColor =
| Pants
| Shorts
| Skirt
| Blank

type Bottom = { color: Color; bottom: BottomNoColor }

type ShoesNoColor =
| Sneakers
| CowboyBoots
| CombatBoots
| Heels
| Slippers

type Shoes = { color: Color; shoes: ShoesNoColor }

type AccessoryNoColor =
| Flower
| Star
| Glasses
| Sunglasses
| Scarf
| Gloves

type Accessory = { color: Color; accessory: AccessoryNoColor }

type Expr = { emotion: Emotion; animal: Animal; top: Top; bottom: Bottom; shoes: Shoes; accessory: Accessory }