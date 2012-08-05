// 素数判定
let isPrime x =
  if x <= 2 then true else
  seq { 
    yield 2 
    yield! seq { 3..2..(float x**0.5|>floor|>int) } }
  |> Seq.forall(fun d->x%d<>0)

seq { 2..99 } 
|> Seq.filter isPrime
|> Seq.iter(printfn"%3d")

// 素数を列挙
open System.Collections.Generic
let primes x =
  let ps = HashSet([2;3])
  for x in 4..x do
    if ps |> Seq.forall(fun p->x%p<>0) then
      ps.Add x |> ignore
  ps
primes 30
|> Seq.iter(printfn"%3d")
