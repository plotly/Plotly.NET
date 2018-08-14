namespace FSharp.Plotly.Tests

open FsCheck
open System

module GeneratorsCode =

//https://msdn.microsoft.com/en-us/library/system.char.iswhitespace(v=vs.110).aspx
    let spaceSeparator = [
        '\u0020'
        '\u1680'
        '\u2000'
        '\u2001'
        '\u2002'
        '\u2003'
        '\u2004'
        '\u2005'
        '\u2006'
        '\u2007'
        '\u2008'
        '\u2009'
        '\u200A'
        '\u202F'
        '\u205F'
        '\u3000'
    ]

    let lineSeparator = ['\u2028']

    let paragraphSeparator = ['\u2029']

    let miscWhitespace = [
        '\u0009'
        '\u000A'
        '\u000B'
        '\u000C'
        '\u000D'
        '\u0085'
        '\u00A0'
    ]

    let whiteSpace = 
        List.concat [spaceSeparator; lineSeparator; paragraphSeparator; miscWhitespace]

    let nonDigitalString() = 
        gen {  
                let! a = Arb.generate<NonEmptyString> 
                return! Gen.elements [a.ToString()] 
        }
        |> Gen.filter(fun x -> 
                        let (isInt, _) =Int32.TryParse x 
                        not isInt) 

    let whitespaceString() =
        let length = 
            Gen.sample 1 1 <| Gen.choose (1, 30)
            |> List.head
            |> int

        Gen.arrayOfLength length <| Gen.elements whiteSpace
        |> Gen.map (fun x -> new string(x))

    let nonEmptyNonAllWhitespaceString() =
        gen {
            return!
                Arb.generate<NonEmptyString> 
        }
        |> Gen.filter (fun x -> 
            let charA = x.ToString().ToCharArray()
            Array.fold (fun s t -> 
                if List.exists (fun x' -> x' = t) whiteSpace |> not then true
                else s
                    ) false charA )
        |> Gen.map (fun x -> x.ToString())

    let genNonEmptyNonAllWhitespaceStringList() =
        let positiveInt = Arb.generate<PositiveInt> 
        let length = 
            Gen.sample 30 1 positiveInt
            |> List.head
            |> int

        Gen.listOfLength length <| nonEmptyNonAllWhitespaceString()

    let genDigitsInWhiteSpace () =
        gen {
                let! frontWhitespace = whitespaceString()
                let! digits = Arb.generate<NonNegativeInt>
                let! endWhitespace = whitespaceString()
                return sprintf "%s%s%s" frontWhitespace (digits.ToString()) endWhitespace
        }

    let validDigits digits length =
        if digits.ToString().Length = length then
            digits.ToString()
        elif digits.ToString().Length < length then
            digits.ToString().PadLeft(length, '0')
        else
            digits.ToString().Substring(0, length)

    let invalidDigits digits length =
        if digits.ToString().Length = length then
            sprintf "0%s" <| digits.ToString()
        else
            digits.ToString()

    let genDigitsOfLengthInWhiteSpace length =
        gen {
                let! frontWhitespace = whitespaceString()
                let! digits = Arb.generate<NonNegativeInt>
                let! endWhitespace = whitespaceString()
                return sprintf "%s%s%s" frontWhitespace (validDigits digits length) endWhitespace |> Some
        }
        |> Gen.filter Option.isSome
        |> Gen.map (fun x -> x.Value)

    let inputZip5Plus4() =
        gen {
            let! digits = Arb.generate<NonNegativeInt>
            return validDigits digits 9
        }

    let genUsPhone7() =
        gen {
                let! digitsExchange = Arb.generate<NonNegativeInt>
                let exchange = validDigits digitsExchange 3
                let! digitsSuffix = Arb.generate<NonNegativeInt>
                let suffix = validDigits digitsSuffix 4
                let! divide = Gen.elements["";"-";" -";"  -";"- ";"-  ";" ";" ";]
                let! start = Gen.elements["";" ";]
                let! after = Gen.elements["";" ";]

                return sprintf "%s%s%s%s%s" start exchange divide suffix after
        }

    let genUsPhone10() =
        gen {
                let! digitsAreaCode = Arb.generate<NonNegativeInt>
                let areaCode = validDigits digitsAreaCode 3
                let! usPhone7 = genUsPhone7()
                let! start = Gen.elements["";" ";"(";"( ";"(  ";" (";"  (";" ( ";]
                let! divide = Gen.elements["";" ";")";" )";"  )";") ";")  ";" ) ";]

                return sprintf "%s%s%s%s" start areaCode divide usPhone7
        }

    let genUsPhone() =
        gen {
            let! usPhone7 = genUsPhone7()
            let! usPhone10 = genUsPhone10()
            return! Gen.elements [usPhone7; usPhone10]
        }

    let genUsPhoneList() =
        Gen.listOf <| genUsPhone()

    let genOtherPhone() =
        //other phone accespts any digit at least 5 and no more than 14 long
        //to do: fix to reject international prefixes
        gen {
            let! length = Gen.choose (5, 14)
            return! genDigitsOfLengthInWhiteSpace length
        }
        

    let genOtherPhoneList() =
        Gen.listOf <| genOtherPhone()

    let genPhoneList() =
        gen {
            let! usPhone = genUsPhoneList()
            let! otherPhone = genOtherPhoneList()
            return
                usPhone
                |> List.append otherPhone
                |> List.sortDescending
        }

    let genCallingCode() =
        let callingCode digits length = 
            let x = validDigits digits length
            if x.StartsWith("0") then
                x.Replace("0", "1")
            else x
            |> UInt16.Parse
        
        gen { 
            let! digits = Arb.generate<NonNegativeInt>
            let! callingCode = Gen.elements [callingCode digits 4 |> Some; callingCode digits 3 |> Some; callingCode digits 2 |> Some; callingCode digits 1 |> Some; None]

            return callingCode
        }

    let genPhoneNumber() =
        gen {
            let! callingCodeRaw = genCallingCode()
            let callingCode = callingCodeRaw |> Option.map (fun x -> x.ToString())

            let! usPhone = genUsPhone()
            let! otherPhone = genOtherPhone()
            let! phone = Gen.elements[usPhone; otherPhone]
            let! extensionRaw = Arb.generate<NonNegativeInt>

            let! extension = Gen.elements [extensionRaw.ToString() |> Some; None]

            let! whiteSpace1Raw = whitespaceString()
            let! whiteSpace2Raw = whitespaceString()
            let! whiteSpace3Raw = whitespaceString()
            let! whiteSpace4Raw = whitespaceString()
            let! whiteSpace5Raw = whitespaceString()

            let! whiteSpace1 = Gen.elements [whiteSpace1Raw |> Some; None]
            let! whiteSpace2 = Gen.elements [whiteSpace2Raw |> Some; None]
            let! whiteSpace3 = Gen.elements [whiteSpace3Raw |> Some; None]
            let! whiteSpace4 = Gen.elements [whiteSpace4Raw |> Some; None]
            let! whiteSpace5 = Gen.elements [whiteSpace5Raw |> Some; None]

            let symbolValueWhitespace symbol value whiteSpace =
                 sprintf "%s%s%s%s" symbol (defaultArg whiteSpace String.Empty) value (defaultArg whiteSpace String.Empty)

            let phoneNumber = 
                sprintf "%s%s%s%s%s%s" 
                    (defaultArg whiteSpace1 String.Empty)
                    (match callingCode with | Some x -> symbolValueWhitespace "+" x whiteSpace2 | None -> String.Empty)
                    phone
                    (defaultArg whiteSpace3 String.Empty)
                    (match extension with | Some x -> symbolValueWhitespace "X" x whiteSpace4 | None -> String.Empty)
                    (defaultArg whiteSpace5 String.Empty)
             
            return (callingCode, phone, extension, phoneNumber)  
        }

    let genUri() =
        gen {
            let! uriRaw = nonEmptyNonAllWhitespaceString()
            let! uri = Gen.elements [" http://" + uriRaw; " https://" + uriRaw; " ftp://" + uriRaw; " ftps://" + uriRaw;]
            return uri
        }
        
type Generators =
        static member NonEmptyStringList() =
            {new Arbitrary<string list>() with
                override __.Generator = 
                    GeneratorsCode.genNonEmptyNonAllWhitespaceStringList()
                    }
