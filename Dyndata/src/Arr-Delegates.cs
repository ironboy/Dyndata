namespace Dyndata;
// Delegates used for iterative methods in Arr

public delegate void _vd(dynamic item);
public delegate void _vdi(dynamic item, int index);
public delegate void _vdiA(dynamic item, int index, Arr array);
public delegate dynamic _dd(dynamic item);
public delegate dynamic _ddi(dynamic item, int index);
public delegate dynamic _ddiA(dynamic item, int index, Arr array);
public delegate bool _bd(dynamic item);
public delegate bool _bdi(dynamic item, int index);
public delegate bool _bdiA(dynamic item, int index, Arr array);
public delegate dynamic _ddd(dynamic accumulator, dynamic current);
public delegate dynamic _dddi(dynamic accumulator, dynamic curent, int index);
public delegate dynamic _dddiA(dynamic accummulator, dynamic current, int index, Arr array);
public delegate dynamic _ddd2(dynamic item1, dynamic item2);