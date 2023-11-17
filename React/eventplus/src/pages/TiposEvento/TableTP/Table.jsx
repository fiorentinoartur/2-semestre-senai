    import React from 'react';
    import './Table.css'
    import editPen from '../../../assets/icons/edit-pen.svg'
    import trashDelete from '../../../assets/icons/trash-delete.svg'
    const Table = ({dados, fnDelete = null, fnUpdate = null}) => {
        return (
            <table className='table-data'>
                {/* cabeçalho */}
                <thead className="table-data__head">
                <tr className="table-data__head-row">
                    <th className="table-data__head-title table-data__head-title--big">Título</th>
                    <th className="table-data__head-title table-data__head-title--little">Editar</th>
                    <th className="table-data__head-title table-data__head-title--little">Deletar</th>
                </tr>
            </thead>
                {/* corpo */}
        
<tbody>
    {dados.map((tp) => {
  return (
      
      <tr className="table-data__head-row" key={tp.idTipoEvento}>
        <td className="table-data__data table-data__data--big">
          {tp.titulo}
        </td>

        <td className="table-data__data table-data__data--little">
          <img 

          className="table-data__icon" 
          src={editPen} 
          alt="" 
          onClick={(e) => {
            //fnUpdate(e.target.getAttribute('idtipoevento'))
            fnUpdate(tp.idTipoEvento)
          }}
          />
        </td>

        <td className="table-data__data table-data__data--little">
          <img 
          idtipoevento={tp.idTipoEvento}
          className="table-data__icon" 
          src={trashDelete} 
          alt="" 
          onClick={(e) => {
            fnDelete(e.target.getAttribute('idtipoevento'))
          }}
          
          />
        </td>
      </tr>
  );
})}
</tbody>
            </table>
                
    
        );
    };
    
    export default Table;