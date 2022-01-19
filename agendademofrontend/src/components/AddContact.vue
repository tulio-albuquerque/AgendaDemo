<template>
  <div id="add" class="modal-container">
    <div class="modal">
      <section>
        <header class="modal-header">
          <span @click="cancel">&times;</span>
          <h2>Adicionar novo contato</h2>
        </header>
        <div class="card__content--body">
          <div class="form-control">
            <label for="name">Nome</label>
            <input type="text" id="name" v-model="contact.name"/>
            <i class="fas fa-check-circle"></i>
            <i class="fas fa-exclamation-circle"></i>
            <small>Error message</small>
          </div>
          <div class="form-control">
            <label for="phone">Telefone</label>
            <input type="tel" id="phone" v-model="contact.phone"/>
            <i class="fas fa-check-circle"></i>
            <i class="fas fa-exclamation-circle"></i>
            <small>Error message</small>
          </div>
          <div class="form-control">
            <label for="email">E-Mail</label>
            <input type="email" id="email" v-model="contact.email" />
            <i class="fas fa-check-circle"></i>
            <i class="fas fa-exclamation-circle"></i>
            <small>Error message</small>
          </div>
        </div>
        <footer class="modal-footer">
          <button class="modal-button" @click="cancel">Cancel</button>
          <button class="modal-button modal-confirm-button"
            @click="add($event)">
            Adicionar
          </button>
        </footer>
      </section>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: "AddContact",
  data() {
    return {
      contact: {
        name: "",
        phone: "",
        email: "",
      }
    }
  },
  methods: {
    validateName(name) {
      let res = /[a-zA-Z][a-zA-Z ]{1,}/;
      return res.test(name);
    },
    validatePhone(phone) {
      let res = /^\\([0-9]{2}\\)((3[0-9]{7})|(9[0-9]{8}))$/
      return res.test(phone)
    },
    validateEmail(email) {
      let res = /^\\w+([\\.-]?\w+)*@\w+([\\.-]?\w+)*(\\.\w{2,3})+$/
      return res.test(email)
    },
    cancel() {
      let confirmation = document.getElementById("add");
      confirmation.classList.remove("modal-open");
    },
    add(event) {
      if (event) {
        event.preventDefault()
      }

      if(!this.validateName(this.contact.name))
        document.getElementById("name").parentElement
          .classList.add("error")
      else {
        axios.post("/contacts", this.contact)
        this.$emit("close", "add")
        this.clear()
      }
    },
    clear() {
      this.contact.name = "",
      this.contact.phone = "",
      this.contact.email = ""
    }
  },
};
</script>

<style scoped>
.modal-container {
  z-index: 9999;
  position: fixed;
  left: 0;
  top: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: none;
  align-items: center;
  justify-content: center;
}

.modal-open {
  display: flex;
}

.modal {
  max-width: 700px;
  max-height: 700px;
  background-color: white;
  border-radius: 3px;
}

.modal-button {
  text-transform: uppercase;
  padding: 0.5em 1em;
  border: none;
  color: white;
  background-color: rgba(0, 0, 0, 0.5);
  border-radius: 3px;
  margin-left: 0.5em;
}

.modal-confirm-button {
  background-color: tomato;
}

.modal-header {
  background-color: rgba(0, 0, 0, 0.1);
  display: flex;
  flex-direction: column;
}

.modal-header h2 {
  margin: 1em;
}

.modal-header span {
  align-self: flex-end;
  padding-right: 0.3em;
  cursor: default;
}

.modal-content {
  padding: 1em;
}

.modal-footer {
  padding: 1em;
  background-color: rgba(0, 0, 0, 0.05);
  display: flex;
  justify-content: flex-end;
}

/*  */

.card__content--body {
  display: flex;
  flex-direction: column;
  gap: 20px;
  padding: 20px;
}

/* add */

.form-control label {
  display: inline-block;
  margin-bottom: 5px;
}

.form-control input {
  border: 2px solid #f0f0f0;
  border-radius: 4px;
  display: block;
  font-family: inherit;
  font-size: 14px;
  padding: 10px;
  width: 100%;
}

.form-control i {
  visibility: hidden;
  position: absolute;
  top: 40px;
  right: 10px;
}

.form-control small {
  visibility: hidden;
  position: absolute;
  bottom: 0;
  left: 0;
}
</style>