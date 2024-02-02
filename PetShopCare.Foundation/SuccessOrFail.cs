namespace PetShopCare.Foundation;

// non voglio restituire un'istanza dell'oggetto User
// i metodi CRUD tendono a cambiare quindi non conviene l'immutabilità

// come vogliamo rappresentare i fallimenti del nostro sistema?

// IDEA: metodo salva, due motivi diversi di salvataggio e di errore,
// il primo dati non validi (tipo string, binary data, troncate e il secondo è il NotFound)
// nell'update (non essendo una ricerca non necessita del Found e NotFound)
// per capire public Enum Category e mettere abbastanza valori per distinguere fondamentalmente la
// tipologia dell'errore per gli status code: dati non validi, entità non trovata ed errore interno
// facciamo questi 3 che rappresentano gli errori di programmazione, potrei aggiungere altre categorie
// switch sullo switch e in base alle categorie restituisci l'errore dettagliato
public abstract record Error(string message);

public abstract record SuccessOrFail();

public record Success : SuccessOrFail;

public record Fail(Error Error) : SuccessOrFail;
