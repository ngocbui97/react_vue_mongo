import * as constants from './constants'

export default{
    addTask({commit},value){
        commit(constants.MUTATION_ADD_TASK,value)
    },
    editTask({commit},task){
        commit(constants.MUTATION_EDIT_TASK,task)
    },
    beginEdit({commit},id){
        commit(constants.MUTATION_BEGIN_EDIT,id)
    },
    deleteTask({commit},id){
        commit(constants.MUTATION_DELETE_TASK,id)
    }

}