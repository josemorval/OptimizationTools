# Vector Optimization

TODO
----
- Construir pools con una capacidad fijada, en lugar de dejarlo dinámicamente: `new List(capacity)`
- Hacer un wrapper de los elementos que queramos en el pool, de manera que las referencias del pool se hagan sobre esa clase y no sobre el tipo valor considerado.
- Cambiar sistema de pool: seguir usando dos listas, pero en un lugar de una con referenciados y otra no referenciados, usar una con todas las referencias y otra de tipo IntArray que tiene la información de quien está activa y quién no.
