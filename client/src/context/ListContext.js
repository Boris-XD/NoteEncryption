import React, { useEffect } from 'react';
import { createContext, useState } from 'react';
import { GetInformation } from '../services/information/Get';

const ListContext = createContext();
function ListProvider({ children }) {
  const [idRootContainer, setIdRootContainer] = useState('');
  const [idContainer, setIdContainer] = useState(idRootContainer);
  const [nameContainer, setNameContainer] = useState('Root');

  const rootIdContainer = (id) => {
    setIdRootContainer(id);
  };
  const selectContainer = (id) => {
    setIdContainer(id);
  };
  const selectContainerName = (name) => {
    setNameContainer(name);
  };
  useEffect(() => {
    setIdContainer(idRootContainer);
  }, [idRootContainer]);

  const [encryptionSelected, setEncryptionSelected] = useState('Binary');

  const selectEncryption = () => {};

  const [addItem, setAddItem] = useState(true);

  const addItemselected = () => {
    setAddItem(!addItem);
  };

  const [filterSelected, setFilterSelected] = useState('All');
  const selectFilter = (filter) => {
    setFilterSelected(filter);
  };

  const [filterSelectedShare, setFilterSelectedShare] = useState('All');
  const selectFilterShare = (filter) => {
    setFilterSelectedShare(filter);
  };

  const [dataSearch, SetDataSearch] = useState('');
  const SearchList = (list) => {
    SetDataSearch(list);
  };
  const dataContainer = {
    idRootContainer,
    rootIdContainer,
    idContainer,
    selectContainer,
    selectContainerName,
    nameContainer,
    encryptionSelected,
    selectEncryption,
    addItem,
    addItemselected,
    filterSelected,
    selectFilter,
    filterSelectedShare,
    selectFilterShare,
    dataSearch,
    SearchList,
  };
  return (
    <ListContext.Provider value={dataContainer}>
      {children}
    </ListContext.Provider>
  );
}

export { ListProvider };
export default ListContext;
