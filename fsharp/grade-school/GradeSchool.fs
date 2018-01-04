module GradeSchool

let empty: Map<int, string list> =
    Map.empty

let add (student: string) (grade: int) (school: Map<int, string list>): Map<int, string list> =
    match school.TryFind(grade) with
    | Some(names) -> school.Add(grade,  List.sort (names @ [ student ]) )
    | None -> school.Add(grade, [ student ] )
    

let roster (school: Map<int, string list>): (int * string list) list =
    let tuples = [ for (KeyValue(k, v)) in school -> (k, v) ]
    
    List.sortBy (fun (k, v) -> k) tuples

let grade (number: int) (school: Map<int, string list>): string list =
    match school.TryFind(number) with
    | Some(names) -> names
    | None -> []
