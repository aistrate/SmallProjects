expr = let ttrue = (\x -> \y -> x) in
       let ffalse = (\x -> \y -> y) in
       let iif = (\b -> \l -> \r -> (b l) r) in
       iif ttrue ffalse ttrue

main = let toBool bbool = bbool True False
       in print . toBool $ expr
-- prints False
