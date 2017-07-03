using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITransferable{

    ITransferable Transfer(GameObject newParent);
}
